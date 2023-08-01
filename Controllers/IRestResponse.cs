internal interface IRestResponse
{
    bool IsSuccessful { get; }
    string Content { get; }
}