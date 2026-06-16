using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using System;

partial class Build : NukeBuild {

    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [GitRepository]
    readonly GitRepository GitRepository;


    [Solution]
    readonly Solution Solution;

    AbsolutePath SourceDirectory => RootDirectory / "src";

    //AbsolutePath ArtifactsDirectory => Path.GetTempPath() + "\\artifacts";
    AbsolutePath ArtifactsDirectory => @"D:\Scratch\_build\vsfbld\";

    LocalBuildConfig settings;

#if false
    Target Clean => _ => _
        .Before(Restore)
        .Executes(() => {
        });

    Target Restore => _ => _
        .Executes(() => {
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() => {
        });
#endif

    Target Initialise => _ => _
     .Before(PrepareStep)
     .Executes(() => {

         if (Solution == null) {
             Logger.Error("Solution is null");
             throw new InvalidOperationException("The solution must be set");
         }


         settings = new LocalBuildConfig();
         settings.ArtifactsDirectory = @"D:\Scratch\_build\vsfbld\";
         settings.NonDestructive = false;
         settings.VersioningPersistanceToken = @"D:\Scratch\_build\vstore\plisky-plumbing.vstore";
         settings.MainProjectName = "Plisky.Plumbing";


         if (settings.NonDestructive) {
             Logger.Info("Initialised - In Non Destructive Mode.");
         } else {
             Logger.Info("Initialised - In Destructive Mode.");
         }

     });

}
