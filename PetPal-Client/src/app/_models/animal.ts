import { Photo } from './photo';

export interface Animal {
    id: number;
    name: string;
    knownAs: string;
    dateOfBirth: Date;
    created: Date;
    age: number;
    gender: number;
    interests: string;
    favoriteTreat: string;
    favoriteToy: string;
    photoUrl: string;
    photos: Photo[];
}