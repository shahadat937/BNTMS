export interface ErrorLog {
    errorLogId: number;
    subject?: string | null;
    failureCount?: number | null;
    fileUpload?: string | null;
    dateTime?: Date | null;
    fileUrl?: string | null;
  }
  