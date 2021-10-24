using OOPAssignment.Interfaces;
using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class Surface : ISurface , ICollidableSurface , Interfaces.IObserver<CarInfo>
    {
        public long _Width;
        public long _Height;

        private readonly List<CarInfo> ObservableCars = new List<CarInfo>();

        long ISurface.Width => _Width;

        long ISurface.Height => _Height;

        public Surface(long width, long height)
        {
            _Width = width;
            _Height = height;
        }



        public bool IsCoordinatesInBounds(Coordinates coordinates)
        {
            long x = coordinates.X;
            long y = coordinates.Y;

            if (x >= _Width || y >= _Height || x < 0 || y < 0)
                return false;
            else
                return true;
        }
        public bool IsCoordinatesEmpty(Coordinates coordinates)
        {
            long x = coordinates.X;
            long y = coordinates.Y;
            if(ObservableCars != null)
                for (int i = 0; i < ObservableCars.Count; i++)
                    if (ObservableCars[i].Coordinates.X == x && ObservableCars[i].Coordinates.Y == y)
                        return false;
            return true;
        }

        public void Update(CarInfo provider)
        {
            CarInfo car = ObservableCars.FirstOrDefault(x => x.CarId == provider.CarId);

            if (GetObservables().Contains(provider))
                car.Coordinates = provider.Coordinates;
            else if (
                IsCoordinatesEmpty(provider.Coordinates) || car.Coordinates.X != provider.Coordinates.X || car.Coordinates.Y != provider.Coordinates.Y)
                ObservableCars.Add(provider);
            else
                throw new Exception();
        }
        public List<CarInfo> GetObservables()
        {
            List<CarInfo> list = new List<CarInfo>();
            if (ObservableCars != null)
            {
                foreach (var item in ObservableCars)
                    list.Add(item);
            }
            return list;
        }
    }
}