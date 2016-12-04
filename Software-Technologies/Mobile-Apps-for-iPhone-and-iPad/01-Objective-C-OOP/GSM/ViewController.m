//
//  ViewController.m
//  GSM
//
//  Created by s i on 1/26/16.
//  Copyright © 2016 svetlai. All rights reserved.
//

#import "ViewController.h"
#import "GSM.h"
#import "GSMFactory.h"
#import "DetailsViewController.h"

@interface ViewController (){
    NSString *selectedValue;
}

@end

@implementation ViewController
//NSMutableArray *gsms;
- (void)viewDidLoad {
    [super viewDidLoad];
//    GSM* samsung = [GSM gsmWithModel:@"S3" andManufacturer:@"Samsung"];
//    GSM* nokia = [GSM gsmWithModel:@"1522" andManufacturer:@"Nokia"];
 //   gsms = [NSMutableArray arrayWithObjects:samsung, nokia, nil];
    
     [self.tableView setDataSource:self];
    [self.tableView setDelegate:self];
    // Do any additional setup after loading the view, typically from a nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)buttonCreateTap:(id)sender {
    NSString *model = self.gsmModel.text;
    NSString *manufacturer = self.gsmManufacturer.text;
    double price = [self.gsmPrice.text doubleValue];
    
    if (model.length == 0 || manufacturer.length == 0){
        [[[UIAlertView alloc] initWithTitle:nil message: @"Model and manufacturer are obligatory." delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil]
         show];
        
        return;
    }
    
    if (isnan(price)){
        [[[UIAlertView alloc] initWithTitle:nil message: @"Please enter a valid price." delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil]
         show];
        
        return;
    }
    
    GSM* gsm = [GSM gsmWithModel:model andManufacturer:manufacturer];
    
    if (!isnan(price)){
        gsm.price = price;
    }
    
    [gsms addObject:gsm];
    [[[UIAlertView alloc] initWithTitle:nil message: @"GSM added successfully." delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil]
     show];
    [self.tableView reloadData];
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return gsms.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    NSString* cellIdentifier = @"cellcell";
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIdentifier];
    
    if(!cell){
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:cellIdentifier];
    }
    
    cell.textLabel.text = [gsms[indexPath.row] description];
    cell.tag = indexPath.row;

    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    //Value Selected by user
    selectedValue = [gsms objectAtIndex:indexPath.row];
    //Initialize new viewController
//    DetailsViewController *viewController = [[DetailsViewController alloc] initWithNibName:@"DetailsViewController" bundle:nil];
//    //Pass selected value to a property declared in NewViewController
//    viewController.details = selectedValue;
//    //Push new view to navigationController stack
//    [self.navigationController pushViewController:viewController animated:YES];
    [self performSegueWithIdentifier:@"segueShowDetails" sender:tableView];
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if([segue.identifier isEqualToString:@"segueShowDetails"]){
        DetailsViewController* toVC = segue.destinationViewController;
        toVC.details = [selectedValue description];
        
    }
}


@end
