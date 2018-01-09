namespace System.Web.Caching
{
    public interface ICacheDependencyChanged {
        void DependencyChanged(object sender, EventArgs e);
    }
}