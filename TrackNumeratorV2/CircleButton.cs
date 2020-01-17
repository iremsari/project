using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackNumeratorV2
{
    class CircleButton:Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(20, 0, 60, ClientSize.Height); 
            this.Region = new System.Drawing.Region(graphics);
            base.OnPaint(pevent);
        }
    }
}
