void Main()
{
    var artSchool = new ArtSchool();
    artSchool.TeachStudents();

    var mathSchool = new MathSchool();
    mathSchool.TeachStudents();
}


// Creators containing the factory method
public abstract class School
{
    public void TeachStudents()
    {
        var teacher = CreateTeacher();
        teacher.Dump($"Teacher fetched for {GetType().Name}");
        teacher.Teach();
    }

    protected abstract ITeacher CreateTeacher();
}

public class ArtSchool : School
{
    protected override ITeacher CreateTeacher()
        => new ArtTeacher();
}

public class MathSchool : School
{
    protected override ITeacher CreateTeacher()
        => new MathTeacher();
}


// Product objects
public interface ITeacher
{
    void Teach();
}

public class ArtTeacher : ITeacher
{
    public void Teach()
        => "Teaching art".Dump(nameof(MathTeacher));
}

public class MathTeacher : ITeacher
{
    public void Teach()
        => "Teaching maths".Dump(nameof(MathTeacher));
}
