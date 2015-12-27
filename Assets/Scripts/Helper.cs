namespace Assets
{
    internal class Helper
    {
        public static bool InRange(float value, float bootom, float end)
        {
            return value >= bootom && value <= end;
        }
    }
}