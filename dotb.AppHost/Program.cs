IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<ProjectResource> apiService = builder.AddProject<Projects.dotb_ApiService>("apiservice");

builder.AddProject<Projects.dotb_portal>("dotb-portal");

builder.AddProject<Projects.dotb_glitter_service>("dotb-glitter-service");

builder.AddProject<Projects.dotb_releases_service>("dotb-releases-service");

builder.Build().Run();