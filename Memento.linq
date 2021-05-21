<Query Kind="Program" />

void Main()
{
	var player = new Player();
	
	player.Play();
	player.Play();
	player.Play();

	player.RollBack();
	player.RollBack();
	
	player.Play();
	player.RollBack();
}

class Player
{
	List<Position> Memory = new ();
	Piece Piece = new ();

	public void Play()
	{
		// Remember the position
		var currentPosition = Piece.GetPosition();
		Memory.Add(currentPosition);
		
		// Go onto the new one
		var nextMove = new Random().Next(1, 6);
		Piece.Move(nextMove);
	}
	
	public void RollBack()
	{
		var lastPosition = Memory.Last();
		Memory.Remove(lastPosition);
		
		Piece.SetPosition(lastPosition);
	}
}

// Empty interface wrapping the inner-state of the object memorized
public interface Position { }

public class Piece
{
	// Private usage of the interface, allows the state to be used by Piece but not by
	// any other class
	private class Cell : Position
	{
		public int Index { get; set; }
		
		public Cell Clone()
			=> new Cell { Index = Index };
	}
	
	// Private instance of the position, only visible by the class itself
	private Cell _cell = new Cell() 
	{
		Index = 0.Dump("Starting at:")
	};
	
	public void Move(int n)
		=> (_cell.Index += n).Dump("Moving, now at:");
		
	// The exposed state is hidden under the interface which hides any of its fields
	public Position GetPosition()
		=> _cell.Clone();
		
	public void SetPosition(Position position)
	{
		if (position is not Cell)
			throw new Exception("Not a position the Piece can handle");
		
		_cell = (Cell) position;
		_cell.Index.Dump("Position set at:");
	}
}
