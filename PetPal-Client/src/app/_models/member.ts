import { Animal } from './Animal';

export interface Member {
    id: number;
    username: string;
    age: number;
    created: Date;
    lastActive: Date;
    introduction: string;
    lookingFor: string;
    city: string;
    country: number;
    language: number;
    animals: Animal[];
}


