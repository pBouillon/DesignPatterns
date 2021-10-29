void Main()
{
	var house = new House(8);

	var architect = new Architect();
	house.Accept(architect);
}

// Visitor
public interface IHouseVisitor
{
	void visitRoom(Room room);
	void visitFloor(Floor floor);
	void visitHouse(House house);
}

public class Architect : IHouseVisitor
{
	public void visitRoom(Room room)
		=> Console.Write($"[{room.Name}]");

	public void visitFloor(Floor floor)
		=> Console.Write($"\n#{floor.Level}: ");

	public void visitHouse(House house)
		=> $"Visiting a new house of {house.Floors.Count} floors:".Dump(nameof(Architect));
}

// Visited elements
public class Room
{
	public string Name { get; init; }

	public Room(string name) => Name = name;

	public void Accept(IHouseVisitor visitor) => visitor.visitRoom(this);
}

public class Floor
{
	public int Level { get; init; }

	public List<Room> Rooms { get; init; }

	public Floor(int level, int roomsCount)
	{
		Level = level;
		Rooms = Enumerable.Range(0, roomsCount)
			.Select(index => new Room(index.ToString()))
			.ToList();
	}

	public void Accept(IHouseVisitor visitor)
	{
		visitor.visitFloor(this);
		Rooms.ForEach(room => room.Accept(visitor));
	}
}

public class House
{
	public List<Floor> Floors { get; init; }

	public House(int floorsCount) 
		=> Floors = Enumerable.Range(0, floorsCount)
			.Select(index => new Floor(index, new Random().Next(1, 4)))
			.ToList();

	public void Accept(IHouseVisitor visitor)
	{
		visitor.visitHouse(this);
		Floors.ForEach(floor => floor.Accept(visitor));
	}
}
