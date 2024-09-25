using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace BattleShips.Models
{
    public class Field
    {
        public FieldCell[][] MapLayout;
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Field(string name, int rows, int columns)
        {
            Name = name;
            Rows = rows;
            Columns = columns;
            BuildMap();
        }
        private void BuildMap()
        {
            Random rnd = new Random();
            MapLayout = new FieldCell[Rows][];
            for (int i = 0; i < Rows; i++)
            {
                MapLayout[i] = new FieldCell[Columns];
                for (int j = 0; j < Columns; j++)
                {
                    MapLayout[i][j] = new FieldCell
                    {
                        RowIndex = i,
                        ColIndex = j,
                        ShipID = null,
                        IsShot = false,
                    };
                }
            }
        }
        public bool CanPlaceShip(Ship ship, FieldCell beginingCell)
        {
            if (ship.IsVertical)
            {
                if (beginingCell.RowIndex + ship.Length > Rows)
                    return false;

                //Tikrinam ar laivu pakeliu nera
                for (int i = 0; i < ship.Length; i++)
                {
                    if (MapLayout[beginingCell.RowIndex + i][beginingCell.ColIndex].ShipID != null)
                        return false;
                }
            }
            else
            {
                if (beginingCell.ColIndex + ship.Length > Columns)
                    return false;

                //Tikrinam ar laivu pakeliu nera
                for (int i = 0; i < ship.Length; i++)
                {
                    if (MapLayout[beginingCell.RowIndex][beginingCell.ColIndex + i].ShipID != null)
                        return false;
                    
                }
            }

            return true;
        }

        public void PlaceShipOnMap(Ship ship, FieldCell beginingCell)
        {
            if (!CanPlaceShip(ship, beginingCell))
            {
                throw new InvalidOperationException("Neina laiva padet!!!");
            }

            if (ship.IsVertical)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    MapLayout[beginingCell.RowIndex + i][beginingCell.ColIndex].ShipID = ship.ShipID;
                }
            }
            else
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    MapLayout[beginingCell.RowIndex][beginingCell.ColIndex + i].ShipID = ship.ShipID;
                }
            }
        }
    }
}
