using System.Drawing;

namespace ZachetniyRadaktor.Drawings
{
    public abstract class Figure : IDrawable
    {
        protected Size dragOffset = new Size(0, 0);

        protected bool isSelected = false;
        private bool isEnabled = true;

        protected Color color;
        protected Point position;
        protected Size size;

        public event EventHandler appearanceChanged;
        public event EventHandler colorChanged;

        public virtual Color Color
        {
            get => color;
            set
            {
                color = value;
                colorChanged?.Invoke(this, EventArgs.Empty);
                OnAppearanceChanged();
            }
        }
        public virtual Point Position
        {
            get => position;
            set
            {
                position = value;
                OnAppearanceChanged();
            }
        }

        protected void OnAppearanceChanged()
        {
            appearanceChanged?.Invoke(this, EventArgs.Empty);
        }

        public virtual Size Size
        {
            get => size;
            set
            {
                size = value;
                OnAppearanceChanged();
            }
        }
        public virtual bool IsEnabled
        {
            get => isEnabled;
            set
            {
                isEnabled = value;
                OnAppearanceChanged();
            }
        }
        public Point Center => Position + Size / 2;


        protected Figure(Point position, Size size, Color color)
        {
            this.color = color;
            this.position = position;
            this.size = size;
        }

        public abstract void DrawFigureAt(Graphics gr, Point location);
        public abstract void DrawOutline(Graphics gr, Point location);
        public void DrawInEditor(Graphics gr, System.Drawing.Rectangle rect)
        {
            DrawFigureAt(gr, rect.Location + rect.Size / 2 - Size / 2);
        }

        public virtual void DragTo(Point location)
        {
            Position = location - dragOffset;
        }

        public void Draw(Graphics gr)
        {
            if (isSelected && IsEnabled) DrawOutline(gr, position);
            DrawFigureAt(gr, Position);
        }


        protected virtual bool IsTouched(Point touchPosition)
        {
            return isEnabled && position.X < touchPosition.X && touchPosition.X < position.X + size.Width &&
                position.Y < touchPosition.Y && touchPosition.Y < position.Y + size.Height;
        }

        public bool HandleTouch(Point touchPosition)
        {
            var res = IsTouched(touchPosition);
            dragOffset = new Size(touchPosition.X - position.X, touchPosition.Y - position.Y);
            return res;
        }

        public virtual void Select()
        {
            isSelected = true;
            OnAppearanceChanged();
        }

        public virtual void Deselect()
        {
            isSelected = false;
            OnAppearanceChanged();
        }
        // "(position) (size) (color)"
        public override string ToString()
        {
            return $"({position.X},{position.Y}) ({size.Width},{size.Height}) ({color.A},{color.R},{color.G},{color.B})";
        }
    }
}