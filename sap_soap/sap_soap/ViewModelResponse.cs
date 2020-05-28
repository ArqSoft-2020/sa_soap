namespace sap_soap
{
    public class ViewModelResponse
    {
        public bool Error { get; set; }
        public string Response { get; set; }
        public ViewModelUser User { get; set; }
        public object Token { get; set; }
        public string Uri { get; set; }
    }
}