namespace EasyValidator.Entity.Models {
    public enum Status {
        Initialize = 0,
        Validating = 1,
        Validated = 2,
        Rejected = 3,
        UploadSuccess = 4,
        UploadFailed = 5,
        Finished = 6,
    }
}