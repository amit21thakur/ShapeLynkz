namespace DrawShapesService.Reader
{
    public class ValueReader : IDataReader
    {
        public string ReadData(string word, string resultJson)
        {
            resultJson += $"\"value\":\"{word}\"}},";
            return resultJson;
        }
    }
}
