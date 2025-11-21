namespace ScheduleApp
{
    public interface ITransformStrategy
    {
        void Transform(string xmlPath, string xslPath, string htmlPath);
    }
}