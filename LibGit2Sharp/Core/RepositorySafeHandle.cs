namespace LibGit2Sharp.Core
{
	public class RepositorySafeHandle : SafeHandleBase
    {
        protected override bool ReleaseHandle()
        {
            NativeMethods.git_repository_free(handle);
            return true;
        }
    }
}
