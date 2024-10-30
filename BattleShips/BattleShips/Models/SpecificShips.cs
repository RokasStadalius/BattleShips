using System.Security.Cryptography.X509Certificates;

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
        public override Ship MakeCopy()
        {
            return(Ship)this.MemberwiseClone();
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
        public override Ship MakeCopy()
        {
            return (Ship)this.MemberwiseClone();
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
        public override Ship MakeCopy()
        {
            return (Ship)this.MemberwiseClone();
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
        public override Ship MakeCopy()
        {
            return (Ship)this.MemberwiseClone();
        }
    }
}
