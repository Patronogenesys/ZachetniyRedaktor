using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetniyRadaktor.Drawings;
using ZachetniyRadaktor.Factories;
using ZachetniyRadaktor.Factories.Read;
using ZachetniyRadaktor.Factories.Rnd;

namespace ZachetniyRadaktor
{
    internal class DragNDrop : IDrawable
    {
        private System.Drawing.Rectangle spawnArea;

        private Figure? beingDragged = null;
        private Figure? selected = null;

        private List<List<Figure>> allFigures = new();

        private List<Figure> rects = new();
        private List<Figure> ellipses = new();
        private List<Figure> cars = new();

        private IFactory<Ellipse> ellipseFactory;
        private IFactory<Drawings.Rectangle> rectFactory;
        private IFactory<Car> carFactory;

        private IFactory<IEnumerable<Ellipse>> ellipseReadFactory;
        private IFactory<IEnumerable<Drawings.Rectangle>> rectReadFactory;
        private IFactory<IEnumerable<Car>> carReadFactory;

        public event EventHandler appearanceChanged;

        public bool unsavedChanges { get; private set; } = true;

        public int RectsNum
        {
            get => rects.Count;
            set
            {
                if (value < 0 || value == rects.Count)
                    return;

                if (value < rects.Count)
                {
                    for (int i = rects.Count; i > value; i--)
                    {
                        var item = rects[^1];
                        item.appearanceChanged -= (sender, args) => OnAppearanceChanged();
                        rects.RemoveAt(rects.Count - 1);
                    }
                }
                else
                {
                    for (int i = rects.Count; i < value; i++)
                    {
                        Drawings.Rectangle item = rectFactory.Create();
                        item.appearanceChanged += (sender, args) => OnAppearanceChanged();
                        rects.Add(item);
                    }
                }
                OnAppearanceChanged();
            }
        }
        public int EllipsesNum
        {
            get => ellipses.Count;
            set
            {
                if (value > 10 || value < 0 || value == ellipses.Count)
                    return;


                if (value < ellipses.Count)
                {
                    for (int i = ellipses.Count; i > value; i--)
                    {
                        var item = ellipses[^1];
                        item.appearanceChanged -= (sender, args) => OnAppearanceChanged();
                        ellipses.RemoveAt(ellipses.Count - 1);
                    }
                }
                else
                {
                    for (int i = ellipses.Count; i < value; i++)
                    {
                        var item = ellipseFactory.Create();
                        item.appearanceChanged += (sender, args) => OnAppearanceChanged();
                        ellipses.Add(item);
                    }
                }
                OnAppearanceChanged();
            }
        }
        public int CarsNum
        {
            get => cars.Count;
            set
            {
                if (value > 10 || value < 0 || value == cars.Count)
                    return;


                if (value < cars.Count)
                {
                    for (int i = cars.Count; i > value; i--)
                    {
                        var item = cars[^1];
                        item.appearanceChanged -= (sender, args) => OnAppearanceChanged();
                        cars.RemoveAt(cars.Count - 1);
                    }
                }
                else
                {
                    for (int i = cars.Count; i < value; i++)
                    {
                        var item = carFactory.Create();
                        item.appearanceChanged += (sender, args) => OnAppearanceChanged();
                        cars.Add(item);
                    }
                }
                OnAppearanceChanged();
            }
        }


        public DragNDrop(System.Drawing.Rectangle spawnArea)
        {
            this.spawnArea = spawnArea;
            ellipseFactory = new EllipseDefaultFactory(spawnArea, 50, 100);
            rectFactory = new RectangleDefaultFactory(spawnArea, 50, 100);
            carFactory = new CarDefaultFactory(spawnArea, 50, 100);

            allFigures.Add(ellipses);
            allFigures.Add(rects);
            allFigures.Add(cars);
        }

        public void OnMouseDown(object? sender, MouseEventArgs e)
        {
            beingDragged = Hitted(e.Location);
            if (beingDragged != null)
            {
                selected?.Deselect();
                beingDragged.Select();
                selected = beingDragged;
            }
            else
            {
                selected?.Deselect();
                selected = null;
            }
        }
        public void OnMouseUp(object? sender, MouseEventArgs e)
        {
            beingDragged = null;
        }
        public void OnMouseMove(object? sender, MouseEventArgs e)
        {
            if (beingDragged != null)
            {
                beingDragged.DragTo(e.Location);
            }
        }

        public Figure? Hitted(Point location)
        {
            Figure? res = null;
            foreach (var figures in allFigures)
            {
                foreach (var f in figures)
                {
                    if (f.HandleTouch(location))
                    {
                        res = f;
                    }
                }
            }
            return res;
        }

        public void SetEllipseEnableAt(int index, bool value) => ellipses[index].IsEnabled = value;
        public void SetRectEnableAt(int index, bool value) => rects[index].IsEnabled = value;
        public void SetCarEnableAt(int index, bool value) => cars[index].IsEnabled = value;

        public void Draw(Graphics gr)
        {
            foreach (var figures in allFigures)
            {
                foreach (var f in figures)
                {
                    f.Draw(gr);
                }
            }
        }

        public void OnTimerTick()
        {
            foreach (Car c in cars)
            {
                c.OnTimerTick();
            }
        }

        public void Save()
        {
            StreamWriter streamWriter = new("rects.txt");
            foreach (var f in rects)
            {
                var result = f.ToString();
                streamWriter.WriteLine(f.ToString());
            }
            streamWriter.Close();

            streamWriter = new("ellipses.txt");
            foreach (var f in ellipses)
            {
                streamWriter.WriteLine(f.ToString());
            }
            streamWriter.Close();

            streamWriter = new("cars.txt");
            foreach (var f in cars)
            {
                streamWriter.WriteLine(f.ToString());
            }
            streamWriter.Close();
            unsavedChanges = false;
        }
        public void Load()
        {
            string[] R = File.ReadAllLines("rects.txt");
            string[] E = File.ReadAllLines("ellipses.txt");
            string[] C = File.ReadAllLines("cars.txt");

            rectReadFactory = new RectangleReadFactory(R);
            ellipseReadFactory = new EllipseReadFactory(E);
            carReadFactory = new CarReadFactory(C);

            rects = new(rectReadFactory.Create());
            ellipses = new(ellipseReadFactory.Create());
            cars = new(carReadFactory.Create());

            allFigures.Clear();
            allFigures.Add(ellipses);
            allFigures.Add(rects);
            allFigures.Add(cars);

            foreach (var figures in allFigures)
            {
                foreach (var f in figures)
                {
                    f.appearanceChanged += (_, _) => OnAppearanceChanged();
                }
            }
            OnAppearanceChanged();
            unsavedChanges = false;
        }

        private void OnAppearanceChanged()
        {
            appearanceChanged?.Invoke(this, EventArgs.Empty);
            unsavedChanges = true;
        }
    }
}
