import { Photo } from './photo';

export interface Member {
    id: number;
    username: string;
    knownAs: string;
    gender: string;
    mood: string;
    age: number;
    dateOfBirth: Date;
    created: Date;
    lastActive: Date;
    introduction: string;
    lookingFor: string;
    city: string;
    country: number;
    language: number;
    photoUrl: string;
    photos: Photo[];
}