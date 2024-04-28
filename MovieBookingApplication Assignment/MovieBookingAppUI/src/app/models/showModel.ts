import { Time } from "@angular/common";

export interface AddMovieShowModel{
    StartDate: Date;
    EndDate: Date;
    StartTime: string;
    EndTime: string;
    TotalSeats: number;
    Price: number;
    ScreenId: number;
    MovieId: string;
}