// =====COPYRIGHT=====
// Code originally retrieved from http://www.vbforums.com/showthread.php?t=547778 - no license information supplied
// =====COPYRIGHT=====
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToastNotifications
{
    /// <summary>
    /// Animates a form when it is shown, hidden or closed
    /// </summary>
    /// <remarks>
    /// MDI child forms do not support the Fade method and only support other methods while being displayed for the first time and when closing
    /// </remarks>
    internal sealed class FormAnimator
    {
#region Constants

        /// <summary>
        /// Hide the form
        /// </summary>
        private const int AwHide = 0x10000;
        /// <summary>
        /// Activate the form
        /// </summary>
        private const int AwActivate = 0x20000;
        /// <summary>
        /// The number of milliseconds over which the animation occurs if no value is specified
        /// </summary>
        private const int DefaultDuration = 70;

#endregion // Constants

#region Variables

        /// <summary>
        /// The form to be animated
        /// </summary>
        private readonly Form _form;

        #endregion // Variables

#region Properties

        /// <summary>
        /// Gets or sets the animation method used to show and hide the form
        /// </summary>
        /// <value>
        /// The animation method used to show and hide the form
        /// </value>
        /// <remarks>
        /// <b>Roll</b> is used by default if no method is specified
        /// </remarks>
        public AnimationMethod Method { get; set; }

        /// <summary>
        /// Gets or Sets the direction in which the animation is performed
        /// </summary>
        /// <value>
        /// The direction in which the animation is performed
        /// </value>
        /// <remarks>
        /// The direction is only applicable to the <b>Roll</b> and <b>Slide</b> methods
        /// </remarks>
        public AnimationDirection Direction { get; set; }

        /// <summary>
        /// Gets or Sets the number of milliseconds over which the animation is played
        /// </summary>
        /// <value>
        /// The number of milliseconds over which the animation is played
        /// </value>
        public int Duration { get; set; }

        /// <summary>
        /// Gets the form to be animated
        /// </summary>
        /// <value>
        /// The form to be animated
        /// </value>
        public Form Form => _form;

        #endregion // Properties

#region Constructors

        /// <summary>
        /// Creates a new <b>FormAnimator</b> object for the specified form
        /// </summary>
        /// <param name="form">
        /// The form to be animated
        /// </param>
        /// <remarks>
        /// No animation will be used unless the <b>Method</b> and/or <b>Direction</b> properties are set independently. The <b>Duration</b> is set to quarter of a second by default.
        /// </remarks>
        public FormAnimator(Form form)
        {
            _form = form;

            _form.Load += Form_Load;
            _form.VisibleChanged += Form_VisibleChanged;
            _form.Closing += Form_Closing;

            Duration = DefaultDuration;
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a new <b>FormAnimator</b> object for the specified form using the specified method over the specified duration
        /// </summary>
        /// <param name="form">
        /// The form to be animated
        /// </param>
        /// <param name="method">
        /// The animation method used to show and hide the form
        /// </param>
        /// <param name="duration">
        /// The number of milliseconds over which the animation is played
        /// </param>
        /// <remarks>
        /// No animation will be used for the <b>Roll</b> or <b>Slide</b> methods unless the <b>Direction</b> property is set independently
        /// </remarks>
        public FormAnimator(Form form, AnimationMethod method, int duration) : this(form)
        {
            Method = method;
            if (duration!=0)
                Duration = duration;
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a new <b>FormAnimator</b> object for the specified form using the specified method in the specified direction over the specified duration
        /// </summary>
        /// <param name="form">
        /// The form to be animated
        /// </param>
        /// <param name="method">
        /// The animation method used to show and hide the form
        /// </param>
        /// <param name="direction">
        /// The direction in which to animate the form
        /// </param>
        /// <param name="duration">
        /// The number of milliseconds over which the animation is played
        /// </param>
        /// <remarks>
        /// The <i>direction</i> argument will have no effect if the <b>Center</b> or <b>Fade</b> method is
        /// specified
        /// </remarks>
        public FormAnimator(Form form, AnimationMethod method, AnimationDirection direction, int duration=0) : this(form, method, duration)
        {
            Direction = direction;
        }

        #endregion // Constructors

        #region Event Handlers

        /// <summary>
        /// Animates the form automatically when it is loaded
        /// </summary>
        private void Form_Load(object sender, EventArgs e)
        {
            // MDI child forms do not support transparency so do not try to use the Fade method
            if (_form.MdiParent == null || Method != AnimationMethod.Fade)
            {
                _form.Invoke((MethodInvoker) delegate
                {
                    NativeMethods.AnimateWindow(_form.Handle, Duration, AwActivate | (int) Method | (int) Direction);
                });
            }
        }

        /// <summary>
        /// Animates the form automatically when it is shown or hidden
        /// </summary>
        private void Form_VisibleChanged(object sender, EventArgs e)
        {
            // Do not attempt to animate MDI child forms while showing or hiding as they do not behave as expected
            if (_form.MdiParent == null)
            {
                int flags = (int) Method | (int) Direction;

                if (_form.Visible)
                {
                    flags = flags | AwActivate;
                }
                else
                {
                    flags = flags | AwHide;
                }

                NativeMethods.AnimateWindow(_form.Handle, Duration, flags);
            }
        }

        /// <summary>
        /// Animates the form automatically when it closes
        /// </summary>
        private void Form_Closing(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                // MDI child forms do not support transparency so do not try to use the Fade method.
                if (_form.MdiParent == null || Method != AnimationMethod.Fade)
                {
                    NativeMethods.AnimateWindow(_form.Handle, Duration, AwHide | (int)Method | (int)Direction);
                }
            }
        }

#endregion // Event Handlers
    }
}
