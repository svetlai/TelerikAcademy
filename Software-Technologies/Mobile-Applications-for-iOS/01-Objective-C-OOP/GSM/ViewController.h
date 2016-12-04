//
//  ViewController.h
//  GSM
//
//  Created by s i on 1/26/16.
//  Copyright © 2016 svetlai. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController <UITableViewDataSource, UITableViewDelegate>
@property (weak, nonatomic) IBOutlet UITableView *tableView;

@property (weak, nonatomic) IBOutlet UITextField *gsmModel;
@property (weak, nonatomic) IBOutlet UITextField *gsmManufacturer;
@property (weak, nonatomic) IBOutlet UITextField *gsmPrice;

- (IBAction)buttonCreateTap:(id)sender;


@end

