<Query Kind="Program" />

void Main()
{
	var alarm = new Alarm();
	alarm.AddWatcher(new FireStation());
	alarm.AddWatcher(new PoliceStation());
	alarm.Notify();
}

class Alarm
{
	List<IObserver<Alarm>> observers = new ();

	public void AddWatcher(IObserver<Alarm> observer)
		=> observers.Add(observer);

	public void Notify()
		=> observers.ForEach(observer => observer.Alert(this));
}

interface IObserver<T>
{
	void Alert(T value);
}

class FireStation : IObserver<Alarm>
{
	public void Alert(Alarm alarm)
		=> nameof(FireStation).Dump("Alerted");
}

class PoliceStation : IObserver<Alarm>
{
	public void Alert(Alarm alarm)
		=> nameof(PoliceStation).Dump("Alerted");
}
