namespace FileLoader.Controllers
{
    public class JsonResponse
    {
        private int result;
        private bool success;

        public JsonResponse SetResult(int result)
        {
            this.result = result;
            return this;
        }

        public JsonResponse SetSuccess(bool success)
        {
            this.success = success;
            return this;
        }

        public int GetResult()
        {
            return result;
        }

        public bool GetSuccess()
        {
            return success;
        }

    }
}