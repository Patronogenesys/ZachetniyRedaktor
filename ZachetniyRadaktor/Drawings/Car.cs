using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachetniyRadaktor.Drawings
{
    internal class Car : Figure
    {
        private Size[] speedStates = {
            new Size(1, 0),
            new Size(0, 1),
            new Size(-1, 0),
            new Size(0, -1),
        };
        private const int speedModifier = 3;
        private int currState = 0;
        private int timeInState = 0;

        private Drawings.Rectangle top;
        private Drawings.Rectangle middle;
        private Ellipse left;
        private Ellipse right;

        private Size MiddleOffest => new Size(0, size.Height / 4);
        private Size LeftOffest => new Size(0, size.Height / 2);
        private Size RightOffest => new Size(size.Width - WheelRadius, size.Height / 2);
        public bool IsDriving { get; set; } = false;

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

        public override bool IsEnabled
        {
            set
            {
                top.IsEnabled = value;
                middle.IsEnabled = value;
                left.IsEnabled = value;
                right.IsEnabled = value;
                base.IsEnabled = value;
            }
        }
        private int WheelRadius => size.Height / 2;

        public int MinWidth => size.Height;

        public Car(Point position, Size size, Color color) : base(position, size, color)
        {
            top = new(new(0, 0), new(0, 0), color);
            top.colorChanged += (_, _) => OnAppearanceChanged();
            middle = new(new(0, 0), new(0, 0), color);
            middle.colorChanged += (_, _) => OnAppearanceChanged();
            left = new(new(0, 0), new(0, 0), color);
            left.colorChanged += (_, _) => OnAppearanceChanged();
            right = new(new(0, 0), new(0, 0), color);
            right.colorChanged += (_, _) => OnAppearanceChanged();
            AdjustChildrenPosition();
        }

        public void OnTimerTick()
        {
            if (IsDriving && IsEnabled)
            {
                Position += speedStates[currState] * speedModifier;
                timeInState++;
                if (timeInState > 60)
                {
                    timeInState = 0;
                    currState = ++currState % speedStates.Length;
                }
                OnAppearanceChanged();
            }
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

        public Figure? ChildTouchedInEditor(Point touchPosition, System.Drawing.Rectangle rect)
        {
            var b = touchPosition;
            touchPosition += new Size(Position);
            var a = touchPosition - (rect.Size / 2 - Size / 2);
            if (top.HandleTouch(touchPosition - (rect.Size / 2 - Size / 2 + top.Size / 2))) return top;
            if (middle.HandleTouch(touchPosition - (rect.Size / 2 - Size / 2 + MiddleOffest + middle.Size / 2))) return middle;
            if (left.HandleTouch(touchPosition - (rect.Size / 2 - Size / 2 + LeftOffest + left.Size / 2))) return left;
            if (right.HandleTouch(touchPosition - (rect.Size / 2 - Size / 2 + RightOffest + right.Size / 2))) return right;
            return null;
        }
        protected override bool IsTouched(Point touchPosition)
        {
            var result = top.HandleTouch(touchPosition) || middle.HandleTouch(touchPosition - MiddleOffest) ||
                left.HandleTouch(touchPosition - LeftOffest) || right.HandleTouch(touchPosition - RightOffest);
            if (result) IsDriving = false;
            return result;
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

    }
}
