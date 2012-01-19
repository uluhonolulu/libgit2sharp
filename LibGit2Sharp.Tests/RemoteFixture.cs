using System;
using System.Text;
using LibGit2Sharp.Core;
using LibGit2Sharp.Tests.TestHelpers;
using NUnit.Framework;

namespace LibGit2Sharp.Tests
{
    [TestFixture]
    public class RemoteFixture : BaseFixture
    {
        [Test]
        public void CanGetRemoteOrigin()
        {
            using (var repo = new Repository(StandardTestRepoPath))
            {
                var origin = repo.Remotes["origin"];
                origin.ShouldNotBeNull();
                origin.Name.ShouldEqual("origin");
                origin.Url.ShouldEqual("c:/GitHub/libgit2sharp/Resources/testrepo.git");
            }
        }

        [Test]
        public void GettingRemoteThatDoesntExistThrows()
        {
            using (var repo = new Repository(StandardTestRepoPath))
            {
                repo.Remotes["test"].ShouldBeNull();
            }
        }

		[Test]
		public unsafe void TryToConnectToRemote() {
			RemoteSafeHandle remote = null;
			RepositorySafeHandle repository = null;
			try {
				var path = @"F:\Projects\Fubu\Chpokk";
				var result = NativeMethods.git_repository_open(out repository, PosixPathHelper.ToPosix(path));
				Assert.NotNull(repository);
				Assert.AreEqual(0, result);
				result = NativeMethods.git_remote_new(out remote, repository, "git://github.com/uluhonolulu/Chpokk-Scratchpad.git", "origin");
				Assert.AreEqual(0, result);
				result = NativeMethods.git_remote_connect(remote, 0);
				Assert.AreEqual(0, result);
				var packname = new IntPtr();
				UnSafeNativeMethods.DownloadPackFileOrWhateverVeryNiceMethodNameYouCanThinkOf(remote);
				//result = UnSafeNativeMethods.git_remote_download(out packname, remote);
				//Assert.AreEqual(0, result);
				//Console.WriteLine(packname);
			}
			finally {
				if (remote != null) remote.Dispose();
				if (repository != null) repository.Dispose();
			}

		}
    }
}
