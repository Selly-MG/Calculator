// Decompiled with JetBrains decompiler
// Type: Calculator.Multicontroller
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Calculator.Controls;
using Calculator.Properties;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Multicontroller
    {
        internal static readonly Multicontroller Instance = new Multicontroller();
        private int currentGroupIndex;
        private bool showAllBorders;
        private bool isActive = true;
        private Multicontroller.ControllerMode currentMode;
        private Dictionary<Keys, List<Keys>> leftKeys = new Dictionary<Keys, List<Keys>>();
        private Dictionary<Keys, List<Keys>> rightKeys = new Dictionary<Keys, List<Keys>>();
        private HashSet<Keys> disabledKeys = new HashSet<Keys>(); // Add this line

        public event EventHandler ModeChanged;

        public event EventHandler GroupsChanged;

        public event EventHandler ShouldActivate;

        public event EventHandler TTWindowActivated;

        public event EventHandler AllTTWindowsInactive;

        internal List<ControllerGroup> ControllerGroups { get; } = new List<ControllerGroup>();

        internal int CurrentGroupIndex
        {
            get
            {
                if (this.currentGroupIndex >= this.ControllerGroups.Count)
                {
                    this.currentGroupIndex = 0;
                    this.updateControllerBorders();
                }
                return this.currentGroupIndex;
            }
            private set
            {
                this.currentGroupIndex = value;
                this.updateControllerBorders();
            }
        }

        internal ToontownController LeftController => this.ControllerGroups[this.CurrentGroupIndex].LeftController;

        internal ToontownController RightController => this.ControllerGroups[this.CurrentGroupIndex].RightController;

        public bool ErrorOccurredPostingMessage => this.ControllerGroups.Any<ControllerGroup>((Func<ControllerGroup, bool>)(g => g.LeftController.ErrorOccurredPostingMessage || g.RightController.ErrorOccurredPostingMessage));

        public bool ShowAllBorders
        {
            get => this.showAllBorders;
            set
            {
                if (this.showAllBorders == value)
                    return;
                this.showAllBorders = value;
                this.updateControllerBorders();
            }
        }

        internal bool IsActive
        {
            get => this.isActive;
            set
            {
                this.isActive = value;
                this.updateControllerBorders();
            }
        }

        internal Multicontroller.ControllerMode CurrentMode
        {
            get => this.currentMode;
            set
            {
                if (this.currentMode != value)
                {
                    this.currentMode = value;
                    EventHandler modeChanged = this.ModeChanged;
                    if (modeChanged != null)
                        modeChanged((object)this, EventArgs.Empty);
                }
                this.updateControllerBorders();
            }
        }

        internal Multicontroller()
        {
            this.UpdateKeys();
            for (int count = this.ControllerGroups.Count; count < Settings.Default.numberOfGroups; ++count)
                this.AddControllerGroup();
            this.updateControllerBorders();

            // Initialize the disabled keys
            disabledKeys.Add(Keys.W);
            disabledKeys.Add(Keys.A);
            disabledKeys.Add(Keys.S);
            disabledKeys.Add(Keys.D);
            disabledKeys.Add(Keys.R);
            disabledKeys.Add(Keys.Q);
            disabledKeys.Add(Keys.E);
            disabledKeys.Add(Keys.Enter);
            disabledKeys.Add(Keys.Space);
        }

        internal void UpdateKeys()
        {
            this.leftKeys.Clear();
            this.rightKeys.Clear();
            List<KeyMapping> bindings = SerializedSettings.Default.Bindings;
            for (int index = 0; index < bindings.Count; ++index)
            {
                if (!this.leftKeys.ContainsKey(bindings[index].LeftToonKey))
                    this.leftKeys.Add(bindings[index].LeftToonKey, new List<Keys>());
                if (!this.rightKeys.ContainsKey(bindings[index].RightToonKey))
                    this.rightKeys.Add(bindings[index].RightToonKey, new List<Keys>());
                if (bindings[index].Key != Keys.None && bindings[index].LeftToonKey != Keys.None)
                    this.leftKeys[bindings[index].LeftToonKey].Add(bindings[index].Key);
                if (bindings[index].Key != Keys.None && bindings[index].RightToonKey != Keys.None)
                    this.rightKeys[bindings[index].RightToonKey].Add(bindings[index].Key);
            }
        }

        internal ControllerGroup AddControllerGroup()
        {
            ControllerGroup controllerGroup = new ControllerGroup();
            controllerGroup.LeftController.GroupNumber = controllerGroup.RightController.GroupNumber = this.ControllerGroups.Count + 1;
            controllerGroup.LeftController.TTWindowActivated += new TTWindowActivatedHandler(this.Controller_TTWindowActivated);
            controllerGroup.RightController.TTWindowActivated += new TTWindowActivatedHandler(this.Controller_TTWindowActivated);
            controllerGroup.LeftController.TTWindowDeactivated += new TTWindowActivatedHandler(this.Controller_TTWindowDeactivated);
            controllerGroup.RightController.TTWindowDeactivated += new TTWindowActivatedHandler(this.Controller_TTWindowDeactivated);
            controllerGroup.LeftController.TTWindowClosed += new TTWindowClosedHandler(this.Controller_TTWindowClosed);
            controllerGroup.RightController.TTWindowClosed += new TTWindowClosedHandler(this.Controller_TTWindowClosed);
            this.ControllerGroups.Add(controllerGroup);
            EventHandler groupsChanged = this.GroupsChanged;
            if (groupsChanged != null)
                groupsChanged((object)this, EventArgs.Empty);
            this.updateControllerBorders();
            return controllerGroup;
        }

        internal void RemoveControllerGroup(int index)
        {
            ControllerGroup controllerGroup = this.ControllerGroups[index];
            controllerGroup.LeftController.Shutdown();
            controllerGroup.RightController.Shutdown();
            this.ControllerGroups.Remove(controllerGroup);
            EventHandler groupsChanged = this.GroupsChanged;
            if (groupsChanged == null)
                return;
            groupsChanged((object)this, EventArgs.Empty);
        }

        private void updateControllerBorders()
        {
            if (this.CurrentMode == Multicontroller.ControllerMode.Multi)
            {
                IEnumerable<ControllerGroup> controllerGroups;
                if (!Settings.Default.controlAllGroupsAtOnce)
                    controllerGroups = (IEnumerable<ControllerGroup>)new ControllerGroup[1]
                    {
                        this.ControllerGroups[this.CurrentGroupIndex]
                    };
                else
                    controllerGroups = (IEnumerable<ControllerGroup>)this.ControllerGroups;
                IEnumerable<ControllerGroup> source = controllerGroups;
                foreach (ControllerGroup controllerGroup in this.ControllerGroups)
                {
                    controllerGroup.LeftController.BorderColor = Color.LimeGreen;
                    controllerGroup.RightController.BorderColor = Color.Green;
                    controllerGroup.LeftController.ShowBorder = controllerGroup.RightController.ShowBorder = this.showAllBorders || source.Contains<ControllerGroup>(controllerGroup);
                    controllerGroup.LeftController.ShowGroupNumber = controllerGroup.RightController.ShowGroupNumber = this.ShowAllBorders || this.ControllerGroups.Count > 1;
                }
            }
            else
                this.ControllerGroups.ForEach((Action<ControllerGroup>)(g =>
                {
                    g.LeftController.BorderColor = g.RightController.BorderColor = Color.Violet;
                    g.LeftController.ShowBorder = g.RightController.ShowBorder = this.isActive;
                    g.LeftController.ShowGroupNumber = g.RightController.ShowGroupNumber = this.ControllerGroups.Count > 1;
                }));
        }

        internal bool ProcessKey(Keys key, uint msg = 0, IntPtr lParam = default(IntPtr))
        {
            if (key == Keys.None || disabledKeys.Contains(key)) // Check if the key is disabled
                return false;
            bool flag = false;
            IntPtr wParam = (IntPtr)(int)key;
            if (key == (Keys)Settings.Default.modeKeyCode)
            {
                if (msg == 786U || msg == 256U)
                {
                    if (this.isActive)
                    {
                        this.CurrentMode = this.currentMode != Multicontroller.ControllerMode.Multi ? Multicontroller.ControllerMode.Multi : Multicontroller.ControllerMode.Mirror;
                    }
                    else
                    {
                        EventHandler shouldActivate = this.ShouldActivate;
                        if (shouldActivate != null)
                            shouldActivate((object)this, EventArgs.Empty);
                    }
                    flag = true;
                }
            }
            else if (key == (Keys)Settings.Default.controlAllGroupsKeyCode)
            {
                if (msg == 256U)
                {
                    Settings.Default.controlAllGroupsAtOnce = !Settings.Default.controlAllGroupsAtOnce;
                    EventHandler groupsChanged = this.GroupsChanged;
                    if (groupsChanged != null)
                        groupsChanged((object)this, EventArgs.Empty);
                    this.updateControllerBorders();
                }
            }
            else if (this.isActive)
            {
                if (this.currentMode == Multicontroller.ControllerMode.Multi)
                {
                    if (!Settings.Default.controlAllGroupsAtOnce && this.ControllerGroups.Count > 1 && (key >= Keys.D0 && key <= Keys.D9 || key >= Keys.NumPad0 && key <= Keys.NumPad9))
                    {
                        int num1 = key < Keys.D0 || key > Keys.D9 ? (int)(9 - (105 - key)) : (int)(9 - (57 - key));
                        int num2 = num1 == 0 ? 9 : num1 - 1;
                        if (this.ControllerGroups.Count > num2)
                        {
                            this.CurrentGroupIndex = num2;
                            EventHandler groupsChanged = this.GroupsChanged;
                            if (groupsChanged != null)
                                groupsChanged((object)this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        if (this.leftKeys.ContainsKey(key))
                        {
                            IEnumerable<ToontownController> toontownControllers;
                            if (!Settings.Default.controlAllGroupsAtOnce)
                                toontownControllers = (IEnumerable<ToontownController>)new ToontownController[1]
                                {
                                    this.LeftController
                                };
                            else
                                toontownControllers = this.ControllerGroups.Select<ControllerGroup, ToontownController>((Func<ControllerGroup, ToontownController>)(c => c.LeftController));
                            IEnumerable<ToontownController> source = toontownControllers;
                            foreach (Keys keys in this.leftKeys[key])
                            {
                                Keys actualKey = keys;
                                source.ToList<ToontownController>().ForEach((Action<ToontownController>)(c => c.PostMessage(msg, (IntPtr)(int)actualKey, lParam)));
                            }
                        }
                        if (this.rightKeys.ContainsKey(key))
                        {
                            IEnumerable<ToontownController> toontownControllers;
                            if (!Settings.Default.controlAllGroupsAtOnce)
                                toontownControllers = (IEnumerable<ToontownController>)new ToontownController[1]
                                {
                                    this.RightController
                                };
                            else
                                toontownControllers = this.ControllerGroups.Select<ControllerGroup, ToontownController>((Func<ControllerGroup, ToontownController>)(c => c.RightController));
                            IEnumerable<ToontownController> source = toontownControllers;
                            foreach (Keys keys in this.rightKeys[key])
                            {
                                Keys actualKey = keys;
                                source.ToList<ToontownController>().ForEach((Action<ToontownController>)(c => c.PostMessage(msg, (IntPtr)(int)actualKey, lParam)));
                            }
                        }
                    }
                }
                else if (this.currentMode == Multicontroller.ControllerMode.Mirror)
                {
                    Task.Run(async () =>
                    {
                        foreach (ControllerGroup controllerGroup in this.ControllerGroups)
                        {
                            controllerGroup.LeftController.PostMessage(msg, wParam, lParam);
                            controllerGroup.RightController.PostMessage(msg, wParam, lParam);
                            await Task.Delay(250); // Add a 250ms delay between groups
                        }
                    });
                }
                flag = true;
            }
            return flag;
        }

        private void Controller_TTWindowClosed(object sender)
        {
            if (sender != this.LeftController && sender != this.RightController)
                return;
            EventHandler groupsChanged = this.GroupsChanged;
            if (groupsChanged == null)
                return;
            groupsChanged((object)this, EventArgs.Empty);
        }

        private void Controller_TTWindowActivated(object sender, IntPtr hWnd)
        {
            EventHandler ttWindowActivated = this.TTWindowActivated;
            if (ttWindowActivated == null)
                return;
            ttWindowActivated((object)this, EventArgs.Empty);
        }

        private void Controller_TTWindowDeactivated(object sender, IntPtr hWnd)
        {
            if (!this.ControllerGroups.All<ControllerGroup>((Func<ControllerGroup, bool>)(g => !g.LeftController.TTWindowActive && !g.RightController.TTWindowActive)))
                return;
            EventHandler ttWindowsInactive = this.AllTTWindowsInactive;
            if (ttWindowsInactive == null)
                return;
            ttWindowsInactive((object)this, EventArgs.Empty);
        }

        internal enum ControllerMode
        {
            Multi,
            Mirror,
        }
    }
}
