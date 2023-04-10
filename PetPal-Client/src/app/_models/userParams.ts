import { User } from "./user";

export class UserParams {
    mood: string;
    minAge = 1;
    maxAge = 100;
    pageNumber = 1;
    pageSize = 5;

    constructor(user: User) {
        this.mood = user.mood === 'playful' ? 'playful' : 'calm'
    }
}