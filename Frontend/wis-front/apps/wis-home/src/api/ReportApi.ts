import { CREATE_REPORT } from "./urls.ts";

export const useReportApi = () => {
  async function createReport(
    report: CreateReportDetails,
    token: string
  ): Promise<void> {
    await fetch(CREATE_REPORT, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      credentials: "include",
      body: JSON.stringify(report),
    });
  }

  return { createReport };
};

export interface CreateReportDetails {
  type: string;
  itemId: number;
  userName: string;
  url: string;
  message: string | undefined;
}
