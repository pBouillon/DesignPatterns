void Main()
{
	DataExtractor csvExtractor = new CsvExtractor();
	csvExtractor.ExtractData();

    "---".Dump();

	DataExtractor classifiedExtractor = new ClassifiedDocumentExtractor();
	classifiedExtractor.ExtractData();
}

public abstract class DataExtractor
{
	// This is the template method
	public IEnumerable<string> ExtractData()
	{
		var rawData = GetRawData();
		ExamineRawData(rawData);

		var data = Decipher(rawData);
		ExamineData(data);

		LogExtractedData(data);

		return data;
	}

	// Those are steps that needs to be overriden
	protected abstract string GetRawData();
	protected abstract IEnumerable<string> Decipher(string data);

	// This is a default step that cannot be overriden
	protected void LogExtractedData(IEnumerable<string> data) => "Logging data".Dump(nameof(DataExtractor));	

	// Those are hooks that can be overriden by the subclasses
	protected virtual void ExamineRawData(string data) { }
	protected virtual void ExamineData(IEnumerable<string> data) { }
}

// Variation of the basic DataExtractor
public class CsvExtractor : DataExtractor
{
	protected override string GetRawData()
	{
		"Getting the raw data".Dump(nameof(CsvExtractor));
		return "Template,Method";
	}

	protected override IEnumerable<string> Decipher(string data)
	{
		"Deciphering data".Dump(nameof(CsvExtractor));
		return data.Split(',');
	}
}

public class ClassifiedDocumentExtractor : DataExtractor
{
	protected override string GetRawData()
	{
		"Getting the raw data".Dump(nameof(ClassifiedDocumentExtractor));
		return "###CO-NF-ID-EN-TI-AL###";
	}

	protected override IEnumerable<string> Decipher(string data)
	{
		"Deciphering data".Dump(nameof(ClassifiedDocumentExtractor));
		return data.Trim('#').Split('-');
	}

	protected override void ExamineData(IEnumerable<string> data)
	{
		if (string.Join(string.Empty, data) == "CONFIDENTIAL")
			"Sensitive content found !".Dump(nameof(ClassifiedDocumentExtractor));
	}
}
