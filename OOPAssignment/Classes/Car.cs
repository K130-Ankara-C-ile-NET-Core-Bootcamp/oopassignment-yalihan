using OOPAssignment.Enums;
using OOPAssignment.Interfaces;
using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class Car : ICarCommand, Interfaces.IObservable<CarInfo>
    {
        public Guid Id;
        public Coordinates Coordinates;
        public Direction Direction;
        public ISurface Surface;
        private Interfaces.IObserver<CarInfo> Observer;

        public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
            Coordinates = coordinates;
            Direction = direction;
            Surface = surface;
        }


        public void TurnLeft()
        {
            if (Direction == Direction.N)
                Direction = Direction.W;
            else
                Direction--;
        }

        public void TurnRight()
        {
            if (Direction == Direction.W)
                Direction = Direction.N;
            else
                Direction++;
        }
        public void Move()
        {
            if (Surface.IsCoordinatesInBounds(Coordinates))
                if (Direction == Direction.N)
                    Coordinates.Y++;
                else if (Direction == Direction.E)
                    Coordinates.X++;
                else if (Direction == Direction.S)
                    Coordinates.Y--;
                else if (Direction == Direction.W)
                    Coordinates.X--;
                else
                    throw new Exception("İşlem Başarısız.");
            /*else
                throw new Exception("İşlem Başarısız.");*/

            Notify();
        }

        public void Attach(Interfaces.IObserver<CarInfo> observer)
        {
            Observer = observer;
            Notify();
        }
        public void Notify()
        {
            Observer.Update(new CarInfo(Id, Coordinates));
        }

    }
}
