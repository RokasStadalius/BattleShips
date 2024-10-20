﻿using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BattleShips.Models
{
    public class Field
    {
        #region Parameters
        public FieldCell[][] MapLayout;
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public bool IsReadyToPlay { get; set; }
        private readonly List<IFieldObserver> observers = new List<IFieldObserver>();
        #endregion
        public Field(string name, int rows, int columns)
        {
            Name = name;
            Rows = rows;
            Columns = columns;
            IsReadyToPlay = false;
            BuildMap();
        }

        #region Subject methods

        public void RegisterObserver(IFieldObserver observer)
        {
            observers.Add(observer);
        }

        public void UnregisterObserver(IFieldObserver observer)
        {
            observers.Remove(observer);
        }

        private void NotifyShipPlaced(Ship ship, FieldCell cell)
        {
            foreach (var observer in observers)
            {
                observer.OnShipPlaced(this, ship, cell);
            }
        }

        private void NotifyShotFired(FieldCell cell)
        {
            foreach (var observer in observers)
            {
                observer.OnShotFired(this, cell);
            }
        }

        private void NotifyFieldStateChanged()
        {
            foreach (var observer in observers)
            {
                observer.OnFieldStateChanged(this);
            }
        }

        #endregion

        #region global Map Methods
        public void FireAtCell(FieldCell cell)
        {
            if (!cell.IsShot)
            {
                cell.IsShot = true;
                NotifyShotFired(cell);
                NotifyFieldStateChanged();
            }
        }
        public void PlaceShipOnMap(Ship shipFromList, FieldCell beginingCell)
        {
            if (!CanPlaceShip(shipFromList, beginingCell))
            {
                throw new InvalidOperationException("Neina laiva padet!!!");
            }

            Ship ship;
            ship = shipFromList.MakeCopy();
            ship.ShipID = GeneratyeIDForShip();
            if (ship.IsVertical)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    AddInitialShipCell(beginingCell.RowIndex + i, beginingCell.ColIndex, ship);
                    NotifyShipPlaced(ship, MapLayout[beginingCell.RowIndex + i][beginingCell.ColIndex]);
                }
            }
            else
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    AddInitialShipCell(beginingCell.RowIndex, beginingCell.ColIndex + i, ship);
                    NotifyShipPlaced(ship, MapLayout[beginingCell.RowIndex][beginingCell.ColIndex + i]);
                }
            }

            NotifyFieldStateChanged();
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
                    if (MapLayout[beginingCell.RowIndex + i][beginingCell.ColIndex].CellShip != null ||
                        MapLayout[beginingCell.RowIndex + i][beginingCell.ColIndex].IsAdjacent)
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
                    if (MapLayout[beginingCell.RowIndex][beginingCell.ColIndex + i].CellShip != null ||
                        MapLayout[beginingCell.RowIndex][beginingCell.ColIndex + i].IsAdjacent)
                        return false;

                }
            }

            return true;
        }
        public int GetShipCountInMap(int shipTypeID)
        {
            var list = GetShipData();
            if (list != null)
                return list.Where(n => n.ShipTypeID == shipTypeID).Count();
            else
                return 0;
        }
        public bool IsOutOfShips()
        {
            for (int i = 0; i < MapLayout.Length; i++)
            {
                for (int j = 0; j < MapLayout[i].Length; j++)
                {
                    FieldCell cell = MapLayout[i][j];
                    if (cell.CellShip != null && !cell.IsShot)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

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
                        CellShip = null,
                        IsShot = false,
                    };
                }
            }
        }
        private void AddInitialShipCell (int rowIndex, int colIndex, Ship ship)
        {
            MapLayout[rowIndex][colIndex].CellShip = ship;
            SetAdjacentCell(rowIndex, colIndex - 1);
            SetAdjacentCell(rowIndex - 1, colIndex - 1);
            SetAdjacentCell(rowIndex - 1, colIndex);
            SetAdjacentCell(rowIndex - 1, colIndex + 1);
            SetAdjacentCell(rowIndex, colIndex + 1);
            SetAdjacentCell(rowIndex + 1, colIndex + 1);
            SetAdjacentCell(rowIndex + 1 , colIndex);
            SetAdjacentCell(rowIndex + 1, colIndex - 1);
        }
        private void SetAdjacentCell(int rowIndex, int colIndex)
        {
            try
            {
                if (MapLayout[rowIndex][colIndex].CellShip == null)
                    MapLayout[rowIndex][colIndex].IsAdjacent = true;
            }
            catch { }
        }
        private List<Ship>? GetShipData()
        {
            List<Ship> shipList = new List<Ship>();
            for (int i = 0; i < MapLayout.Length; i++)
            {
                for (int j = 0; j < MapLayout[i].Length; j++)
                {
                    FieldCell cell = MapLayout[i][j];
                    if (cell.CellShip != null)
                    {
                        shipList.Add(cell.CellShip);
                    }
                }
            }

            if (shipList.Count > 0)
            {
                var shipCount = shipList.GroupBy(n => n.ShipID).Select(g => g.First()).ToList();
                return shipCount;
            }

            return null;
        }
        private int GeneratyeIDForShip()
        {
            var list = GetShipData();
            if (list != null)
                return list.Max(n=>n.ShipID) + 1;
            else
                return 0;
        }
       
    }

    public class StandartField : Field
    {
        public StandartField(string name) : base(name, 10, 10) { }
    }

    public class MediumField : Field
    {
        public MediumField(string name) : base(name, 15, 15) { }
    }

    public class AdvancedField : Field
    {
        public AdvancedField(string name) : base(name, 20, 20) { }
    }
}
