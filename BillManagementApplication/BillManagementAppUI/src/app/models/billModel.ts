export interface Bill{
    unitsConsumed: number;
    userId: string;
    perUnitPrice: number;
    loadAllowed: number;
    startDate: Date;
    endDate: Date;
    dueDate: Date;
    lateCharge: number;
}