terraform {
  backend "s3" {
    bucket = "terraform-state-demonstration"
    key    = "development/abeesha"
    region = "us-east-1"
  }
}