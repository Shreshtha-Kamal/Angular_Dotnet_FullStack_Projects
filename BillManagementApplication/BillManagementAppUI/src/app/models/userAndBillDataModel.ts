export interface UserAndRecentBillData{
    userId: string;
    pincode:string;
    name: string;
    loadAllowed: number;
    latestBillAmount: number;
    billStatus: string;
}