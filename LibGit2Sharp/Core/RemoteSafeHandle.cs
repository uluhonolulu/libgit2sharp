namespace LibGit2Sharp.Core
{
	public class RemoteSafeHandle : SafeHandleBase
    {
        protected override bool ReleaseHandle()
        {
            NativeMethods.git_remote_free(handle);
            return true;
        }
    }
}
