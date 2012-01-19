namespace LibGit2Sharp.Core
{
	public class DatabaseSafeHandle : SafeHandleBase
    {
        protected override bool ReleaseHandle()
        {
            NativeMethods.git_odb_free(handle);
            return true;
        }
    }
}
