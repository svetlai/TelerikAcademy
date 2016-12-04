//
//  GSM.m
//  GSM
//
//  Created by s i on 1/26/16.
//  Copyright © 2016 svetlai. All rights reserved.
//

#import "GSM.h"

@implementation GSM

@synthesize model = _model;
@synthesize manufacturer = _manufacturer;

-(instancetype)initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer{
    self = [super init];
    if(self)
    {
        self.model = model;
        self.manufacturer = manufacturer;
        self.price = 0;
        self.owner = nil;
        self.battery = nil;
        self.display = nil;
    }
    
    return self;
}

-(instancetype)initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andPrice: (double) price{
    self = [super init];
    if(self)
    {
        self.model = model;
        self.manufacturer = manufacturer;
        self.price = price;
        self.owner = nil;
        self.battery = nil;
        self.display = nil;
    }
    
    return self;
}

-(instancetype)initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andOwner: (NSString*) owner{
    self = [super init];
    if(self)
    {
        self.model = model;
        self.manufacturer = manufacturer;
        self.owner = owner;
        self.price = 0;
        self.battery = nil;
        self.display = nil;
    }
    
    return self;
}

- (void)setModel:(NSString *)model
{
    if(!model || model.length == 0)
    {
        [NSException raise:@"Invalid model." format:@"Model is a must."];
    }
    
    _model = model;
}

- (NSString *)model
{
    return _model;
}

- (void)setManufacturer:(NSString *)manufacturer
{
    if(!manufacturer || manufacturer.length == 0)
    {
        [NSException raise:@"Invalid manufacturer." format:@"Manufacturer is a must."];
    }
    
    _manufacturer = manufacturer;
}

- (NSString *)manufacturer
{
    return _manufacturer;
}

+(GSM*)gsmWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer;
{
    return [[GSM alloc] initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer];
}

+(GSM*)gsmWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andPrice: (double) price{
    return [[GSM alloc] initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andPrice: (double) price];
}

+(GSM*)gsmWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andOwner: (NSString*) owner{
    return [[GSM alloc] initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andOwner: (NSString*) owner];
}

+(GSM*)IPhone5s {
    return [[GSM alloc] initWithModel: @"iPhone5s" andManufacturer: @"Apple"];
}

- (NSString *)description
{
    return [NSString stringWithFormat:@"Model: %@, Manufacturer: %@, Price: %f, Owner: %@", self.model, self.manufacturer, self.price, self.owner];
}

@end
