﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BobsPanicBox
{
    internal class Editor
    {
        internal AbortValues av;

        internal Editor()
        {
            av = new AbortValues(this);
        }

        public void SaveCurrent(Module_BobsPanicBox m)
        {
            Log.Info("Editor.SaveCurrent");
            av.SaveCurrent(m);
        }
        public bool Changed(Module_BobsPanicBox m)
        {
            return av.Changed(m);
        }

        public void SetAllActive(bool armed, string status)
        {
            Log.Info("SetAllActive, armed: " + armed + ", status: " + status);

            foreach (var p in EditorLogic.fetch.ship.parts)
            {
                var m = p.FindModuleImplementing<Module_BobsPanicBox>();
                if (m != null)
                {
                    m.armed = armed;
                    m.status = status;
                }
            }
        }

        public void SetAllValues(AbortValues a)
        {
            av = a;
            foreach (var p in EditorLogic.fetch.ship.parts)
            {
                var m = p.FindModuleImplementing<Module_BobsPanicBox>();
                if (m != null)
                {
                    m.SetAllValues(av);
                }
            }
        }
    }
}