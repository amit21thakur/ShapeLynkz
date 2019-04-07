namespace DrawShapesService.Reader
{
    public class KeyReader : IDataReader
    {
        public string ReadData(string word, string resultJson)
        {
            resultJson += $"{{\"key\":\"{word}\", ";
            return resultJson;
        }
    }
}
