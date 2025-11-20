using POFF.Kicker.View.Screens;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace POFF.Kicker.View.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public AppWindow m_AppWindow;

            public AppWindow AppWindow
            {
                [DebuggerHidden]
                get
                {
                    m_AppWindow = Create__Instance__(m_AppWindow);
                    return m_AppWindow;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_AppWindow))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_AppWindow);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public ResultDialog m_ResultDialog;

            public ResultDialog ResultDialog
            {
                [DebuggerHidden]
                get
                {
                    m_ResultDialog = Create__Instance__<ResultDialog>(m_ResultDialog);
                    return m_ResultDialog;
                }
                [DebuggerHidden]
                set
                {
                    if (object.ReferenceEquals(value, m_ResultDialog))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__<ResultDialog>(ref m_ResultDialog);
                }
            }

        }


    }
}