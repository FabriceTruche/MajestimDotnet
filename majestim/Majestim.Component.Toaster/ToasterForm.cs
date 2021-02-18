// =====COPYRIGHT=====
// Code originally retrieved from http://www.vbforums.com/showthread.php?t=547778 - no license information supplied
// =====COPYRIGHT=====
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToastNotifications
{
    internal  partial class ToasterForm : Form
    {
        private static readonly List<ToasterForm> OpenNotifications = new List<ToasterForm>();
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;
        private Form _currentForm;
        private Point _currentFormLocation;

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="toasterType"></param>
        /// <param name="duration"></param>
        /// <param name="animation"></param>
        /// <param name="direction"></param>
        public ToasterForm(Form form, string title, string body, ToasterType toasterType, int duration, AnimationMethod animation, AnimationDirection direction)
        {
            InitializeComponent();

            if (duration < 0)
                duration = int.MaxValue;
            else
                duration = duration * 1000;

            this._currentForm = form;
            lifeTimer.Interval = duration;
            labelBody.Text = body;
            labelTitle.Text = title;
            toolTip1.InitialDelay = 0;
            toolTip1.SetToolTip(labelBody, body);
            _animator = new FormAnimator(this, animation, direction);
            _currentForm.Resize += CurrentFormOnResize;
            _currentForm.Move += CurrentFormOnMove;
            _currentFormLocation = _currentForm.Location;
            SetToasterType(toasterType);
        }

        #region Methods

        /// <summary>
        /// Displays the form
        /// </summary>
        /// <remarks>
        /// Required to allow the form to determine the current foreground window before being displayed
        /// </remarks>
        public void SetToasterType(ToasterType toasterType)
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            switch (toasterType)
            {
                case ToasterType.Success:
                    this.picture.Image = Properties.Resources.success_icon;
                    this.BackColor = Color.Aquamarine;
                    break;
                case ToasterType.Info:
                    this.picture.Image = Properties.Resources.info_icon;
                    this.BackColor = Color.Aqua;
                    break;
                case ToasterType.Warning:
                    this.picture.Image = Properties.Resources.warning_icon;
                    this.BackColor = Color.PapayaWhip;
                    break;
                case ToasterType.Error:
                    this.picture.Image = Properties.Resources.error_icon;
                    this.BackColor = Color.Pink;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(toasterType), toasterType, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void CurrentFormOnMove(object sender, EventArgs eventArgs)
        {
            int deltaX = _currentForm.Location.X - _currentFormLocation.X;
            int deltaY = _currentForm.Location.Y - _currentFormLocation.Y;

            this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            _currentFormLocation = _currentForm.Location;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void CurrentFormOnResize(object sender, EventArgs eventArgs)
        {
            this.Location = new Point(this._currentForm.Location.X + this._currentForm.Width - (30 + this.Width), this.Location.Y);
        }

        #endregion // Methods

        #region Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            //Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            this.Location = new Point(
                this._currentForm.Location.X + this._currentForm.Width - (20 + this.Width),
                this._currentForm.Location.Y + 35);

            // Move each open form upwards to make room for this one
            foreach (ToasterForm openForm in OpenNotifications)
            {
                openForm.Top += Height + 10;
            }

            OpenNotifications.Add(this);
            lifeTimer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(_currentForegroundWindow);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            _allowFocus = true;

            // Close the form by sliding down.
            //_animator.Duration = 0;
            _animator.Direction = AnimationDirection.Down;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (ToasterForm openForm in OpenNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are below this one
                    break;
                }
                openForm.Top -= Height + 10;
            }

            OpenNotifications.Remove(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lifeTimer_Tick(object sender, EventArgs e)
        {
            this.CloseMethod();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notification_Click(object sender, EventArgs e)
        {
            CloseMethod();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelRO_Click(object sender, EventArgs e)
        {
            CloseMethod();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picture_Click(object sender, EventArgs e)
        {
            CloseMethod();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTitle_Click(object sender, EventArgs e)
        {
            CloseMethod();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CloseMethod()
        {
            this.Close();
        }


        #endregion // Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picture_Resize(object sender, EventArgs e)
        {

        }

        private void picture_ControlRemoved(object sender, ControlEventArgs e)
        {
            _currentForm.Resize -= CurrentFormOnResize;
            _currentForm.Move -= CurrentFormOnMove;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}