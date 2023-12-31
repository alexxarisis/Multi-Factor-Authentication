namespace API.Models.Responses
{
    public class RecoveryResponse : MyResponse
    {
        public string recoveryKey = "";

        public RecoveryResponse(MyResponse response) : base(response) { }

        public void SetRecoveryKey(string value)
        {
            recoveryKey = value;
        }
    }
}
