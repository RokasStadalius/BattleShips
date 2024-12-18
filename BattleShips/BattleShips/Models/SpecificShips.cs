﻿using System.Security.Cryptography.X509Certificates;

namespace BattleShips.Models
{
    public class Destroyer : Ship
    {
        public Destroyer(int shipID, int shipTypeID, string shipName) : base(new DestroyerAttackStrategy())
        {
            this.ShipID = shipID;
            this.ShipTypeID = shipTypeID;
            this.MaxPlacementCount = 4;
            this.ShipName = shipName;
            this.Length = 2;
        }
        public override Ship MakeShalowCopy()
        {
            return(Ship)this.MemberwiseClone();
        }
        public override object Clone()
        {
            var clone = new Destroyer(ShipID, ShipTypeID, ShipName)
            {
                MaxPlacementCount = this.MaxPlacementCount,
                Length = this.Length,
                IsVertical = this.IsVertical
            };

            if (this.AttackStrategy != null)
                clone.AttackStrategy = this.AttackStrategy.Clone() as IShipAttackStrategy;


            return clone;
        }

        public override void Accept(IShipVisitor visitor)
        {
            visitor.VisitDestroyer(this);
        }
    }
    public class Submarine : Ship
    {
        public Submarine(int shipID, int shipTypeID, string shipName) : base(new SubmarineAttackStrategy())
        {
            this.ShipID = shipID;
            this.ShipTypeID = shipTypeID;
            this.MaxPlacementCount = 2;
            this.ShipName = shipName;
            this.Length = 3;
            this.AttackStrategy= new SubmarineAttackStrategy();
        }
        public override Ship MakeShalowCopy()
        {
            return (Ship)this.MemberwiseClone();
        }
        public override object Clone()
        {
            var clone = new Submarine(ShipID, ShipTypeID, ShipName)
            {
                MaxPlacementCount = this.MaxPlacementCount,
                Length = this.Length,
                IsVertical = this.IsVertical
            };

            if (this.AttackStrategy != null)
                clone.AttackStrategy = this.AttackStrategy.Clone() as IShipAttackStrategy;


            return clone;
        }

        public override void Accept(IShipVisitor visitor)
        {
            visitor.VisitSubmarine(this);
        }
    }
    public class Battleship : Ship
    {
        public Battleship(int shipID, int shipTypeID, string shipName) : base(new BattleshipAttackStrategy())
        {
            this.ShipID = shipID;
            this.ShipTypeID = shipTypeID;
            this.MaxPlacementCount = 1;
            this.ShipName = shipName;
            this.Length = 4;
        }
        public override Ship MakeShalowCopy()
        {
            return (Ship)this.MemberwiseClone();
        }
        public override object Clone()
        {
            var clone = new Battleship(ShipID, ShipTypeID, ShipName)
            {
                MaxPlacementCount = this.MaxPlacementCount,
                Length = this.Length,
                IsVertical = this.IsVertical
            };

            if (this.AttackStrategy != null)
                clone.AttackStrategy = this.AttackStrategy.Clone() as IShipAttackStrategy;
            

            return clone;
        }

        public override void Accept(IShipVisitor visitor)
        {
            visitor.VisitBattleship(this);
        }

    }
    public class Carrier : Ship
    {
        public Carrier(int shipID, int shipTypeID, string shipName) : base(new CarrierAttackStrategy())
        {
            this.ShipID = shipID;
            this.ShipTypeID = shipTypeID;
            this.MaxPlacementCount = 1;
            this.ShipName = shipName;
            this.Length = 5;
        }

        public override object Clone()
        {
            var clone = new Carrier(ShipID, ShipTypeID, ShipName)
            {
                MaxPlacementCount = this.MaxPlacementCount,
                Length = this.Length,
                IsVertical = this.IsVertical
            };

            if (this.AttackStrategy != null)
                clone.AttackStrategy = this.AttackStrategy.Clone() as IShipAttackStrategy;
            

            return clone;
        }

        public override Ship MakeShalowCopy()
        {
            return (Ship)this.MemberwiseClone();
        }

        public override void Accept(IShipVisitor visitor)
        {
            visitor.VisitCarrier(this);
        }
    }
}
