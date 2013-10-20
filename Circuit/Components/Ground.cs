﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SyMath;
using System.ComponentModel;

namespace Circuit
{
    /// <summary>
    /// Ground component, V = 0.
    /// </summary>
    [CategoryAttribute("Standard")]
    [DisplayName("Ground")]
    public class Ground : OneTerminal
    {
        public Ground() { Name = "GND1"; }

        public override void Analyze(ICollection<Equal> Mna, ICollection<Expression> Unknowns)
        {
            // Nodes connected to ground have V = 0.
            Equal V_0 = Equal.New(Terminal.V, Constant.Zero);
            if (!Mna.Contains(V_0))
                Mna.Add(V_0);
            Terminal.i = null;
        }

        protected override void DrawSymbol(SymbolLayout Sym)
        {
            Sym.AddLoop(EdgeType.Black,
                new Coord(-10, 0),
                new Coord(10, 0),
                new Coord(0, -10));
        }
    }
}
