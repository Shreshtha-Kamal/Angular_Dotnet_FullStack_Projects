export interface CreatedUserModel{
    userName: string;
    name: string;
    email: string;
    phoneNumber: string;
    alternatePhoneNumber: string;
    address: string;
    role?: string;
    pincode: string;
    loadAllowed?: number;
    createdAt: Date;
    password: string;
}