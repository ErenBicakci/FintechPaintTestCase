using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechPaintTestCase.Models
{
    internal class Hexagon : Shape
    {

        public Hexagon(Color color)
        {
            this.setColor(color);
        }
        public override void draw(PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void mouseMove(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
