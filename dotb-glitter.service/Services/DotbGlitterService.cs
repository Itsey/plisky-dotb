using Grpc.Core;
using Plisky.Glitter;
using Plisky.GlitterPortal;
using System.Text.Json;

namespace dotb_glitter.service.Services;

public class DotbGlitterService : DotbGlitter.DotbGlitterBase {
    private readonly ILogger<DotbGlitterService> _logger;
    protected GlitterDbContext db;

    public DotbGlitterService(ILogger<DotbGlitterService> logger, GlitterDbContext ctxt) {
        _logger = logger;
        db = ctxt;
    }

    public override async Task<ServiceResponse> SubmitGlitterReport(AddGlitterReportRequest request, ServerCallContext context) {
        MemoryStream ms = new MemoryStream();
        request.FileContents.WriteTo(ms);
        StreamReader sr = new StreamReader(ms);
        string st = sr.ReadToEnd();

        ReportPayload rpld = JsonSerializer.Deserialize<ReportPayload>(st);

        GlitterDbManager glitterDbManager = new GlitterDbManager(db);
        glitterDbManager.ImportPayload(rpld);

        return new ServiceResponse() {
            ErrorCode = 0,
            Success = true,
            Uid = "Success"
        };
    }
}