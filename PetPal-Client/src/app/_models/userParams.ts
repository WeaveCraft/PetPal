import { User } from "./user";

export class UserParams {
    mood: string;
    minAge = 1;
    maxAge = 14;
    pageNumber = 1;
    pageSize = 6
    orderBy = 'lastActive';

    constructor(user: User) {
        this.mood = user.mood === 'playful' ? 'playful' : 'calm'
    }
}