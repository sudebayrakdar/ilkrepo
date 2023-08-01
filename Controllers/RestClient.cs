internal class RestClient
{
    private string v;

    public RestClient(string v)
    {
        this.v = v;
    }

    internal IRestResponse Execute(RestRequest request)
    {
        throw new NotImplementedException();
    }
}