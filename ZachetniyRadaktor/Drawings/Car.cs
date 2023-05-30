using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachetniyRadaktor.Drawings
{
    internal class Car : Figure
    {


        private Drawings.Rectangle top;
        private Drawings.Rectangle middle;
        private Ellipse left;
        private Ellipse right;

        private Size MiddleOffest => new Size(0, size.Height / 4);
        private Size LeftOffest => new Size(0, size.Height / 2);
        private Size RightOffest => new Size(size.Width - WheelRadius, size.Height / 2);


        public override Color Color
        {
            get => color;
            set
            {
                color = value;
                top.Color = color;
                middle.Color = color;
                left.Color = color;
                right.Color = color;
                OnAppearanceChanged();
            }
        }

        public override Point Position
        {
            set
            {
                position = value;
                AdjustChildrenPosition();
                OnAppearanceChanged();
            }
        }
        public override Size Size
        {
            set
            {
                size = value;
                AdjustChildrenPosition();
                OnAppearanceChanged();
            }
        }

        private int WheelRadius => size.Height / 2;

        public int MinWidth => size.Height;

        public Car(Point position, Size size, Color color) : base(position, size, color)
        {
            top = new(new(0, 0), new(0, 0), color);
            middle = new(new(0, 0), new(0, 0), color);
            left = new(new(0, 0), new(0, 0), color);
            right = new(new(0, 0), new(0, 0), color);
            AdjustChildrenPosition();
        }

        private void AdjustChildrenPosition()
        {
            AdjustTopPosition();
            AdjustMiddlePosition();
            AdjustLeftPosition();
            AdjustRightPosition();
        }

        private void AdjustTopPosition()
        {
            top.Position = position;
            top.Size = new Size(size.Width / 3, size.Height / 4);
        }

        private void AdjustMiddlePosition()
        {
            middle.Position = position;
            middle.Size = new Size(size.Width, size.Height / 4);
        }

        private void AdjustLeftPosition()
        {
            left.Position = position;
            left.Size = new Size(WheelRadius, WheelRadius);
        }

        private void AdjustRightPosition()
        {
            right.Position = position;
            right.Size = new Size(WheelRadius, WheelRadius);
        }

        public override void DrawFigureAt(Graphics gr, Point location)
        {
            top.DrawFigureAt(gr, location);
            middle.DrawFigureAt(gr, location + MiddleOffest);
            left.DrawFigureAt(gr, location + LeftOffest);
            right.DrawFigureAt(gr, location + RightOffest);
        }

        public override void DrawOutline(Graphics gr, Point location)
        {
            top.DrawOutline(gr, location);
            middle.DrawOutline(gr, location + MiddleOffest);
            left.DrawOutline(gr, location + LeftOffest);
            right.DrawOutline(gr, location + RightOffest);
        }

        protected override bool IsTouched(Point touchPosition)
        {
            //dragOffset = new Size(touchPosition.X - position.X, touchPosition.Y - position.Y);
            return top.HandleTouch(touchPosition) || middle.HandleTouch(touchPosition - MiddleOffest) ||
                left.HandleTouch(touchPosition - LeftOffest) || right.HandleTouch(touchPosition - RightOffest);
        }

        public Figure? ChildTouchedInEditor(Point touchPosition, System.Drawing.Rectangle rect)
        {
            touchPosition -= new Size(Position);
            if (top.HandleTouch(touchPosition + rect.Size / 2 - top.Size / 2)) return top;
            if (middle.HandleTouch(touchPosition + MiddleOffest + rect.Size/2 - middle.Size/2)) return middle;
            if (left.HandleTouch(touchPosition + LeftOffest + rect.Size / 2 - left.Size / 2)) return left;
            if (right.HandleTouch(touchPosition + RightOffest + rect.Size / 2 - right.Size / 2)) return right;
            return null;
        }
    }
}
